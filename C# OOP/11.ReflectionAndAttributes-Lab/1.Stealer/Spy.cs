using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _1.Reflection
{
	public class Spy
	{
		// Gets all field from the Hacker class
		public string StealFieldInfo(string className, params string[] fields)
		{
			//Type classType = Type.GetType("_1.Reflection.Hacker");
			Type classType = typeof(Hacker);

			FieldInfo[] classFields = classType
				.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

			StringBuilder sb = new StringBuilder();

			Object classInstance = Activator.CreateInstance(classType, new object[] { });

			sb.AppendLine($"Class under investigation: {className}");

			foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
			{
				sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
			}

			return sb.ToString().TrimEnd();
		}

		//Gets public fields and all methods from the Hacker class
		public string AnalyzeAcessModifiers(string className)
		{
			//Type classType = Type.GetType("_1.Reflection.Hacker");
			Type classType = typeof(Hacker);

			FieldInfo[] classFields = classType
				.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

			MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
			MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

			StringBuilder sb = new StringBuilder();

			foreach (FieldInfo field in classFields)
			{
				sb.AppendLine($"{field.Name} must be private!");
			}
			foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
			{
				sb.AppendLine($"{method.Name} have to be public!");
			}
			foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
			{
				sb.AppendLine($"{method.Name} have to be private!");
			}

			return sb.ToString().TrimEnd();
		}

		//Gets private methods and properties from the Hacker
		public string RevealPrivateMethods(string className)
		{
			//Type classType = Type.GetType("_1.Reflection.Hacker");
			Type classType = typeof(Hacker);

			MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"All Private Methods of Class: {className}");
			sb.AppendLine($"Base Class: {classType.BaseType.Name}");

			foreach (MethodInfo method in classMethods)
			{
				sb.AppendLine(method.Name);
			}

			return sb.ToString().TrimEnd();
		}

		//Gets the types of all methods and properties with getters and setters from the Hacker
		public string CollectGettersAndSetters(string className)
		{
			//Type classType = Type.GetType("_1.Reflection.Hacker");
			Type classType = typeof(Hacker);

			MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

			StringBuilder sb = new StringBuilder();

			foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
			{
				sb.AppendLine($"{method.Name} will return {method.ReturnType}");
			}
			foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
			{
				sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
