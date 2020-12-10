using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator.Common
{
	public static class GlobalConstants
	{
		public static string InvalidStatExceptionMessage =
			"{0} should be between {1} and {2}.";

		public static string EmptyNameExceptionMessage =
			"A name should not be between empty.";

		public static string RemovingMissingPlayerExceptionMessage =
			"Player {0} is not in {1} team.";

		public static string MissingTeamExceptionMessage =
			"Team {0} does not exist.";
	}
}
