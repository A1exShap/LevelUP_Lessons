using Lesson1.Model;
using Lesson1.Helper;

namespace Lesson1.Controller
{
    public sealed class Controller : IController
    {
        private readonly IModel _model;
        
        public List<PersonParameter> PersonParameters => _model.PersonParameters;

        public Dictionary<string, string> Commands =>
            new Dictionary<string, string>
            {
                { "add", "Add new person" },
                { "show [id]", "Show person info by ID" },
                { "show all", "Show all person's info" },
                { "del [id]", "Delete person by ID" },
                { "del all", "Add new person" },
            };
        
        public Controller()
        {
            _model = new Model.Model();
        }

        public bool Execute(string command, out string resultMessage, ref Dictionary<int, List<PersonParameter>>? personParameters)
        {
            switch (command.Split(' ')[0])
            {
                case "add":
                    return Add(out resultMessage, personParameters);
                case "show":
                    return Show(command, out resultMessage, out personParameters);
                case "del":
                    return Delete(command, out resultMessage);
                default:
                    resultMessage = $"Command {command} not found in controller";
                    return false;
            }   
        }

        private bool Add(out string resultMessage, Dictionary<int, List<PersonParameter>>? personParameters)
        {
            try
            {
                var persons = _model.Persons;
                
                var maxId = persons.Count == 0 ? 0 : persons.Keys.Max();
                
                persons.Add(++maxId, personParameters[0]);
                
                _model.Persons = persons;

                resultMessage = $"Person was created with ID: {maxId}";

                return true;
            }
            catch (Exception e)
            {
                resultMessage = e.Message;
                return false;
            }
        }

        private bool Show(string command, out string resultMessage, out Dictionary<int, List<PersonParameter>>? personParameters)
        {
            try
            {
                var id = GetCommandParameter(command);
                
                var persons = _model.Persons;
                
                if (id != -1 && !persons.ContainsKey(id))
                {
                    resultMessage = $"Nothing found for id: {id}";
                    personParameters = null;
                    return false;
                }

                personParameters = id == -1 
                    ? persons
                    : persons.Where(x => x.Key == id).ToDictionary(p => p.Key, p => p.Value);

                resultMessage = id == -1 ? "Persons:" : "Person:";

                return true;
            }
            catch (Exception e)
            {
                resultMessage = e.Message;
                personParameters = null;
                return false;
            }
        }

        private bool Delete(string command, out string resultMessage)
        {
            try
            {
                var id = GetCommandParameter(command);

                var persons = _model.Persons;

                if (id != -1 && !persons.ContainsKey(id))
                {
                    resultMessage = $"Nothing found for id: {id}";
                    return false;
                }

                if (id == -1)
                {
                    _model.SetEmptyJson();
                }
                else
                {
                    persons = persons.Where(x => x.Key != id).ToDictionary(p => p.Key, p => p.Value);
                    _model.Persons = persons;
                }
                
                resultMessage = "Delete successful";

                return true;
            }
            catch (Exception e)
            {
                resultMessage = e.Message;
                return false;
            }
        }
        
        private static int GetCommandParameter(string parameter)
        {
            return !parameter.Contains(" ") 
                   || parameter.Split(' ')[1].Equals("all")                       
                   || !int.TryParse(parameter.Split(' ')[1], out var id)
                
                   ? -1
                   : id;
        }

    }
}