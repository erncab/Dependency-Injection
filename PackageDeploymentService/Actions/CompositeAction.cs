using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PackageDeploymentService.Actions
{
    public class CompositeAction : ActionBase, IEnumerable
    {
        private readonly List<ActionBase> _actions = new List<ActionBase>();

        public List<ActionBase> Add(ActionBase action)
        {
            _actions.Add(action);

            return _actions;
        }

        protected override void ExecuteAction()
        {
            foreach (var action in _actions)
            {
                action.Execute();
            }
        }

        public override string Description
        {
            get
            {
                var sb = new StringBuilder();

                foreach (var action in _actions)
                {
                    sb.AppendLine(action.Description);
                }

                return sb.ToString();
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
