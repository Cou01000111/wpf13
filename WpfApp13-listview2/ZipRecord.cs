using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13_listview2
{
    /// <summary>
    /// 郵便番号データ
    /// </summary>
    public class ZipRecord
    {
        /// <summary>
        /// 全国地方公共団体コード
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// （旧）郵便番号
        /// </summary>
        public string ZipOld { get; set; }

        /// <summary>
        /// 郵便番号
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// 都道府県名カナ
        /// </summary>
        public string StateKana { get; set; }

        /// <summary>
        /// 市区町村名カナ
        /// </summary>
        public string CityKana { get; set; }

        /// <summary>
        /// 町域名カナ
        /// </summary>
        public string TownKana { get; set; }

        /// <summary>
        /// 都道府県名
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 市区町村名
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 町域名
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// 一町域が二以上の郵便番号で表される場合の表示
        /// </summary>
        /// <remarks>
        /// 「1」は該当、「0」は該当せず
        /// </remarks>
        public string Flag1 { get; set; }

        /// <summary>
        /// 小字毎に番地が起番されている町域の表示
        /// </summary>
        /// <remarks>
        /// 「1」は該当、「0」は該当せず
        /// </remarks>
        public string Flag2 { get; set; }

        /// <summary>
        /// 丁目を有する町域の場合の表示
        /// </summary>
        /// <remarks>
        /// 「1」は該当、「0」は該当せず
        /// </remarks>
        public string Flag3 { get; set; }

        /// <summary>
        /// 一つの郵便番号で二以上の町域を表す場合の表示
        /// </summary>
        /// <remarks>
        /// 「1」は該当、「0」は該当せず
        /// </remarks>
        public string Flag4 { get; set; }

        /// <summary>
        /// 更新の表示
        /// </summary>
        /// <remarks>
        /// 「0」は変更なし、「1」は変更あり、「2」廃止（廃止データのみ使用）
        /// </remarks>
        public string Flag5 { get; set; }

        /// <summary>
        /// 変更理由
        /// </summary>
        /// <remarks>
        /// 「0」は変更なし、「1」市政・区政・町政・分区・政令指定都市施行、
        /// 「2」住居表示の実施、「3」区画整理、「4」郵便区調整等、
        /// 「5」訂正、「6」廃止（廃止データのみ使用）
        /// </remarks>
        public string Flag6 { get; set; }
    }
}
