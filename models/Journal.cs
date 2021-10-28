using System;
using System.ComponentModel.DataAnnotations;

namespace ScriptureJournal.Models
{
    public class Journal {
        public int ID { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public string ScriptureText { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
    }
}