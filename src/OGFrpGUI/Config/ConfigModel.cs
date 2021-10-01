using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrpCore
{
    /// <summary>
    /// ConfigModel接口
    /// </summary>
    public interface ConfigModel {}

    public partial class Config
    {

        /// <summary>
        /// 设置：语言
        /// </summary>
        public class Lang : ConfigModel
        {
            public string ConfigVal = "";
        }

        /// <summary>
        /// 将String转换成ConfigModel
        /// </summary>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        public ConfigModel StrToConfigModel(string ModelName)
        {
            switch (ModelName)
            {
                case "lang":
                    break;
                default:
                    break;
            }
        }
    }
}
