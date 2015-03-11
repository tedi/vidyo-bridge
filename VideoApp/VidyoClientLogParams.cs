using System;

namespace VideoApp
{
	public struct VidyoClientLogParams
	{
		public char logLevelsAndCategories;   /*!< levels and categories to log */
		public int logSize;                    /*!< maximum size of each log file */
		public char pathToLogDir;             /*!< path to write log files */
		public char logBaseFileName;          /*!< base file name used for log files */
		public char pathToDumpDir;            /*!< path to write dump files (unused) */
		public char pathToConfigDir;          /*!< path to config.xml file (used by Android */
	}
}