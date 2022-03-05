using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Model
{
    public class TitulService
    {
        private List<Titul> _ObjTituls = null;
        public TitulService()
        {
            _ObjTituls = new List<Titul>()
            {
                new Titul()
                {
                    Id = 1,
                    FileName = "Titul25",
                    TitulId = 6556844,
                    StudentId = 4489,
                    AddedDateTime = DateTime.Now,
                    TitulScanStatus = false,
                    FirstMainScienceQuestions = new List<Keys>()
                    {
                        new Keys() {KeyA = true, KeyB = false, KeyC = false, KeyD = false},
                        new Keys() {KeyA = false, KeyB = true, KeyC = false, KeyD = false},
                        new Keys() {KeyA = false, KeyB = false, KeyC = true, KeyD = false},
                        new Keys() {KeyA = false, KeyB = false, KeyC = false, KeyD = true}
                    }
                },
                new Titul()
                {
                    Id = 2,
                    FileName = "Titul47",
                    TitulId = 445561516,
                    StudentId = 5645,
                    AddedDateTime = DateTime.Now,
                    TitulScanStatus = false,
                    FirstMainScienceQuestions = new List<Keys>()
                    {
                        new Keys() {KeyA = true, KeyB = false, KeyC = false, KeyD = false},
                        new Keys() {KeyA = false, KeyB = true, KeyC = false, KeyD = false},
                        new Keys() {KeyA = false, KeyB = false, KeyC = true, KeyD = false},
                        new Keys() {KeyA = false, KeyB = false, KeyC = false, KeyD = true}
                    }
                }
            };
        }

        // Get Tituls
        public List<Titul> GetTituls()
        {
            return _ObjTituls;
        }

        // Add Titul
        public bool AddTitul(Titul titul)
        {
            if (titul != null)
            {
                _ObjTituls.Add(titul);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete Titul
        public bool DeleteTitul(int idTitul)
        {
            _ObjTituls.RemoveAt(idTitul);
            return true;
        }
    }
}
