using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDataImport.Models
{
    public class OpenData
    {
        /*private int _id;
        public int Id {
            get {
                return _id;
            }
            set {
                this._id = value;
            }
        }*/
        public int id { get; set; }
        public string 資料集名稱 { get; set; }
        public string 主要欄位說明 { get; set; }
        public string 服務分類 { get; set; }


        /* public string Get資料集名稱() {
             return "";
         }*/
    }
}