using System;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>()
                .GetName();
        }
    }
}
