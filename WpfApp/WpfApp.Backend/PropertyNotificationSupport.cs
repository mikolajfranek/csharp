using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace WpfApp.Backend
{
    public abstract class PropertyNotificationSupport : INotifyPropertyChanged
    {
        private class MemberAccessVisitor : ExpressionVisitor
        {
            public override Expression? Visit(Expression? node)
            {
                if (node != null && node.NodeType == ExpressionType.MemberAccess)
                {
                    var memberExpression = (MemberExpression)node;
                    if (memberExpression.Member.DeclaringType == declaringType)
                        PropertyNames.Add(memberExpression.Member.Name);
                }
                return base.Visit(node);
            }

            private readonly Type declaringType;
            public readonly IList<string> PropertyNames = new List<string>();
            public MemberAccessVisitor(Type declaringType)
            {
                this.declaringType = declaringType;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly Dictionary<string, HashSet<String>> affectedBy = new Dictionary<string, HashSet<string>>();

        private void OnPropertyChanged(string propertyName, Dictionary<string, HashSet<String>> passedAffectedBy)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            foreach (var affector in passedAffectedBy.Keys)
                if (passedAffectedBy[affector].Contains(propertyName))
                {
                    passedAffectedBy[affector].Remove(propertyName);
                    OnPropertyChanged(affector, passedAffectedBy);
                }
        }

        public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null) return;
            var deepCopyAffectedBy = affectedBy.DeepCopy();
            OnPropertyChanged(propertyName, deepCopyAffectedBy);
        }

        protected Func<T> Property<T>(string propertyName, Expression<Func<T>> expression)
        {
            //Console.WriteLine($"Tworzenie obliczonej właściwości dla wyrażenia {expression}");
            var visitor = new MemberAccessVisitor(GetType());
            visitor.Visit(expression);
            if (visitor.PropertyNames.Any() == true)
            {
                if (affectedBy.ContainsKey(propertyName) == false)
                    affectedBy.Add(propertyName, new HashSet<string>());
                foreach (var propertyNameFromExpression in visitor.PropertyNames)
                    if (propertyNameFromExpression.Equals(propertyName) == false)
                        affectedBy[propertyName].Add(propertyNameFromExpression);
            }
            return expression.Compile();
        }
    }
}
