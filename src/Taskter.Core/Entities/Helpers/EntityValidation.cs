using System;


namespace Taskter.Core.Entities.Helpers
{
    public static class EntityValidaton
    {
        public static void StringIsNullOrHasAWhiteSpace(string p, string propName)
        {
            if (string.IsNullOrWhiteSpace(p))
                throw new ArgumentException(propName + " cannot be null or empty or contain only whitespace characters!");

        }

    
        public static void StringHasMoreThan15ParametersOrHasWhiteSpaces(string p)
        {
            if (p != null)
            {
                if (p.Length > 15)
                    throw new ArgumentException("Project code cannot contain more than 15 characters!");
                if (p.Contains(" "))
                    throw new ArgumentException("Project code cannot contain whitespaces!");
            }
        }

        public static void ForeignKeyValueValidaton(int key)
        {
            if (key < 1)
                throw new ArgumentException("The ID value can not be less than one!");
        }
    }
}
