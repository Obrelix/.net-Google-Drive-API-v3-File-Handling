using System;
using System.Collections;
using System.IO;
using System.Timers;
using System.Xml.Serialization;

namespace GoogleDriveManager
{
    public class TaskScheduler
    {
        /// <summary>
        /// Art der wöchentlichen Wiederholung, erste, zweit, dritte, vierte oder letzte Woche
        /// </summary>
        public enum DayOccurrence
        {
            First = 0,
            Second = 1,
            Third = 2,
            Fourth = 3,
            Last = 4
        }

        /// <summary>
        /// Monate im Jahr
        /// </summary>
        public enum MonthOfTheYeay
        {
            January = 0,
            February = 1,
            March = 2,
            April = 3,
            May = 4,
            June = 5,
            July = 6,
            August = 7,
            September = 8,
            October = 9,
            November = 10,
            December = 11
        }

        /// <summary>
        /// Einmalige Ausführung: Stellt das Ausführungsdatum dar
        /// </summary>
        public class TriggerSettingsOneTimeOnly
        {
            private DateTime _date;
            private bool _active;

            [XmlIgnore]
            public DateTime Date
            {
                get
                {
                    return _date;
                }
                set
                {
                    _date = value;
                }
            }

            [XmlElement("Date")]
            public string XMLDate
            {
                get { return this._date.ToString("yyyy-MM-dd"); }
                set { this.Date = DateTime.ParseExact(value, "yyyy-MM-dd", null).Date; }
            }

            public bool Active
            {
                get
                {
                    return _active;
                }
                set
                {
                    _active = value;
                }
            }
        }

        /// <summary>
        /// Tägliche Ausführung: Legt den Interval der Ausführung fest
        /// </summary>
        public class TriggerSettingsDaily
        {
            private ushort _Interval;

            public ushort Interval
            {
                get
                {
                    return _Interval;
                }
                set
                {
                    _Interval = value;
                    if (_Interval < 0) _Interval = 0;
                }
            }
        }

        /// <summary>
        /// Wöchentliche Ausführung: Tage an denen der Task ausgeführt werden soll
        /// </summary>
        public class TriggerSettingsWeekly
        {
            private bool[] _DaysOfWeek;
            /// <summary>
            /// Wöchentliche Ausführung: Aktiviert oder deaktiviert einen Wochentag
            /// </summary>
            public bool[] DaysOfWeek
            {
                get
                {
                    return _DaysOfWeek;
                }
                set
                {
                    _DaysOfWeek = value;
                }
            }

            public TriggerSettingsWeekly()
            {
                _DaysOfWeek = new bool[7];
            }
        }

        /// <summary>
        /// Einstellungen für Monatliches Ausführen eines Triggers - Details für DayOfWeek
        /// </summary>
        public class TriggerSettingsMonthlyWeekDay
        {
            private bool[] _WeekNumber;
            private bool[] _DayOfWeek;

            /// <summary>
            /// Monatliche Ausführung: n'tes Vorkommen eines Wochentages
            /// </summary>
            public bool[] WeekNumber
            {
                get
                {
                    return _WeekNumber;
                }
                set
                {
                    _WeekNumber = value;
                }
            }
            /// <summary>
            /// Monatliche Ausführung: Wochentage
            /// </summary>
            public bool[] DayOfWeek
            {
                get
                {
                    return _DayOfWeek;
                }
                set
                {
                    _DayOfWeek = value;
                }
            }

            public TriggerSettingsMonthlyWeekDay()
            {
                _WeekNumber = new bool[5];
                _DayOfWeek = new bool[7];
            }
        }

        /// <summary>
        /// Einstellungen für Monatliches Ausführen eines Triggers
        /// </summary>
        public class TriggerSettingsMonthly
        {
            private bool[] _Month;

            private bool[] _DaysOfMonth;
            private TriggerSettingsMonthlyWeekDay _WeekDay;

            /// <summary>
            /// Monatliche Ausführung: Stellt die aktivierten Monate dar
            /// </summary>
            public bool[] Month
            {
                get
                {
                    return _Month;
                }
                set
                {
                    _Month = value;
                }
            }
            /// <summary>
            /// Monatliche Ausführung: Stellt die Tage vom Monat dar, an denen der Task ausgeführt werden soll
            /// </summary>
            public bool[] DaysOfMonth
            {
                get
                {
                    return _DaysOfMonth;
                }
                set
                {
                    _DaysOfMonth = value;
                }
            }
            /// <summary>
            /// Monatliche Ausführung: Wochentage
            /// </summary>
            public TriggerSettingsMonthlyWeekDay WeekDay
            {
                get
                {
                    return _WeekDay;
                }
                set
                {
                    _WeekDay = value;
                }
            }

            public TriggerSettingsMonthly()
            {
                _Month = new bool[12];
                _DaysOfMonth = new bool[32];
                _WeekDay = new TriggerSettingsMonthlyWeekDay();
            }

        }

        /// <summary>
        /// Einstellungen wann ein Trigger ausgelöst werden soll
        /// </summary>
        public class TriggerSettings
        {
            private TriggerSettingsOneTimeOnly _OneTimeOnly;
            private TriggerSettingsDaily _Daily;
            private TriggerSettingsWeekly _Weekly;
            private TriggerSettingsMonthly _Monthly;

            public TriggerSettingsOneTimeOnly OneTimeOnly
            {
                get
                {
                    return _OneTimeOnly;
                }
                set
                {
                    _OneTimeOnly = value;
                }
            }
            public TriggerSettingsDaily Daily
            {
                get
                {
                    return _Daily;
                }
                set
                {
                    _Daily = value;
                }
            }
            public TriggerSettingsWeekly Weekly
            {
                get
                {
                    return _Weekly;
                }
                set
                {
                    _Weekly = value;
                }
            }
            public TriggerSettingsMonthly Monthly
            {
                get
                {
                    return _Monthly;
                }
                set
                {
                    _Monthly = value;
                }
            }

            public TriggerSettings()
            {
                _OneTimeOnly = new TriggerSettingsOneTimeOnly();
                _Daily = new TriggerSettingsDaily();
                _Weekly = new TriggerSettingsWeekly();
                _Monthly = new TriggerSettingsMonthly();
            }
        }

        /// <summary>
        /// OnTriggerEventArgs
        /// </summary>
        public class OnTriggerEventArgs : EventArgs
        {
            public OnTriggerEventArgs(TriggerItem item, DateTime triggerDate)
            {
                _item = item;
                _triggerDate = triggerDate;
            }
            private TriggerItem _item;
            private DateTime _triggerDate;
            public TriggerItem Item
            {
                get { return _item; }
            }
            public DateTime TriggerDate
            {
                get { return _triggerDate; }
            }
        }

        /// <summary>
        /// Stellt einen Eintrag in der Task-Liste dar
        /// </summary>
        public class TriggerItem
        {
            private DateTime _StartDate = DateTime.MinValue; // Wenn nicht anders angegeben den gesamten Zeitbereich verwenden
            private DateTime _EndDate = DateTime.MaxValue;
            private DateTime _TriggerTime; // Aktuelle Trigger-Ausführung
            private TimeSpan _HitTimeSpan = new TimeSpan(0, 0, 1); // Zeitfenster in dem ein Trigger ausgelöst wird (_TriggerTime + HitTimeWindow)
            private DateTime _NextTriggerDate; // Letzter ausgelöster Trigger
            private TriggerSettings _TriggerSettings; // Trigger-Flags - speichert die Einstellungen wann der Trigger ausgelöst werden soll
            private const byte LastDayOfMonthID = 31; // 0..30 = Tage im Monat, 31=Letzter Tag im Monat
            private object _Tag; // Speichert ein Hilfsobjekt
            private bool _Enabled; // Trigger aktiviert
            public delegate void OnTriggerEventHandler(object sender, OnTriggerEventArgs e);
            public event OnTriggerEventHandler OnTrigger;

            /// <summary>
            /// Erstellt eine Instanz von TriggerItem
            /// </summary>
            public TriggerItem()
            {
                _TriggerSettings = new TriggerSettings();
            }

            /// <summary>
            /// Serialisiert das Object in einen XML-String
            /// </summary>
            /// <returns></returns>
            public String ToXML() // Konfiguration im XML-Format als String ausgeben
            {
                XmlSerializer ser = new XmlSerializer(typeof(TriggerItem));
                TextWriter writer = new StringWriter();
                ser.Serialize(writer, this);
                writer.Close();
                return writer.ToString();
            }

            /// <summary>
            /// Erzeugt ein TriggerItem aus einem XML-String
            /// </summary>
            /// <param name="Configuration"></param>
            /// <returns></returns>
            public static TriggerItem FromXML(string Configuration)
            {
                XmlSerializer ser = new XmlSerializer(typeof(TriggerItem));
                TextReader reader = new StringReader(Configuration);
                TriggerItem result = (TriggerItem)ser.Deserialize(reader);
                reader.Close();
                return result;
            }

            /// <summary>
            /// Speichert ein Hilfsobjekt 
            /// </summary>
            [XmlElement(Order = 0)]
            public object Tag
            {
                get
                {
                    return _Tag;
                }
                set
                {
                    _Tag = value;
                }
            }

            /// <summary>
            /// Stellt das Anfangsdatum der Ausführung dar
            /// </summary>
            [XmlIgnore]
            public DateTime StartDate
            {
                get
                {
                    return _StartDate;
                }
                set
                {
                    _StartDate = value;
                    if (_EndDate < _StartDate) _EndDate = _StartDate;
                }
            }

            [XmlElement("StartDate", Order = 1)]
            public string XMLStartDate
            {
                get { return this._StartDate.ToString("yyyy-MM-dd"); }
                set { this.StartDate = DateTime.ParseExact(value, "yyyy-MM-dd", null); }
            }

            /// <summary>
            /// Stellt das Enddatum der Ausführung dar
            /// </summary>
            [XmlIgnore]
            public DateTime EndDate
            {
                get
                {
                    return _EndDate;
                }
                set
                {
                    _EndDate = value.Date;
                }
            }
            
            [XmlElement("EndDate", Order = 2)]
            public string XMLEndDate
            {
                get { return this._EndDate.ToString("yyyy-MM-dd"); }
                set { this.EndDate = DateTime.ParseExact(value, "yyyy-MM-dd", null); }
            }

            /// <summary>
            /// Stellt die Ausführungs - Uhrzeit dar
            /// </summary>
            [XmlIgnore]
            public DateTime TriggerTime
            {
                get
                {
                    return _TriggerTime;
                }
                set
                {
                    _TriggerTime = new DateTime(_TriggerTime.Year, _TriggerTime.Month, _TriggerTime.Day, value.Hour, value.Minute, value.Second);
                }
            }

            [XmlElement("TriggerTime", Order = 3)]
            public string XMLTriggerTime
            {
                get { return this.TriggerTime.ToString("HH:mm:ss"); } //yyyy-MM-dd 
                set { this.TriggerTime = DateTime.ParseExact(value, "HH:mm:ss", null); }
            }

            /// <summary>
            /// Zeitfenster in dem ein Trigger ausgelöst wird.
            /// Die zu aktuelle Zeit muss im Zeitfenster TriggerTime + HitTimeSpan liegen damit der Trigger ausgelöst wird
            /// </summary>
            private TimeSpan HitTimeSpan
            {
                get
                {
                    return _HitTimeSpan;
                }
                set
                {
                    _HitTimeSpan = value;
                }
            }

            /// <summary>
            /// Ermittelt oder legt fest wann der Trigger ausgelöst werden soll
            /// </summary>
            [XmlElement(Order = 4)]
            public TriggerSettings TriggerSettings
            {
                get
                {
                    return _TriggerSettings;
                }
                set
                {
                    _TriggerSettings = value;
                }
            }

            /// <summary>
            /// Aktiviert oder deaktiviert den Trigger
            /// </summary>
            [XmlElement(Order = 5)]
            public bool Enabled
            {
                get
                {
                    return _Enabled;
                }
                set
                {
                    _Enabled = value;
                    if (_Enabled)
                        _NextTriggerDate = FindNextTriggerDate(DateTime.Now);
                    else
                        _NextTriggerDate = DateTime.MaxValue;
                }
            }

            /// <summary>
            /// Ermittelt den Letzten Tag des angegebenen Monats
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private DateTime LastDayOfMonth(DateTime date)
            {
                return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            }

            /// <summary>
            /// Ermittel das wievielte Mal der Wochentag in diesem Monat an diesem Datum vorkommt
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private int WeekDayOccurInMonth(DateTime date)
            {
                byte count = 0;
                for (int day = 1; day <= date.Day; day++)
                    if (new DateTime(date.Year, date.Month, day).DayOfWeek == date.DayOfWeek)
                        count++;
                return count-1;
            }

            /// <summary>
            /// Ermittelt ob dieser Tag das Letzte mal im Monat vorkommt
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private bool IsLastWeekDayInMonth(DateTime date)
            {
                return (WeekDayOccurInMonth(date.AddDays(7))==0); // Der Wochentag kommt als letztes vor wenn der gleiche Wochentag eine Woche später das Erste mal (im Monat) vorkommt
            }

            /// <summary>
            /// Trigger-Prüfung für einmalige Ausführung
            /// </summary>
            /// <returns></returns>
            private bool TriggerOneTimeOnly(DateTime date)
            {
                return (_TriggerSettings.OneTimeOnly.Active && (_TriggerSettings.OneTimeOnly.Date == date));
            }

            /// <summary>
            /// Trigger-Prüfung für tägliche Ausführung
            /// </summary>
            /// <returns>True wenn an diesem Tag der Task ausgeführt werden soll</returns>
            private bool TriggerDaily(DateTime date)
            {
                if ((date < _StartDate.Date) || (date > _EndDate.Date)) // Wenn das Relevante Datum ausserhalb des gültigen Bereichs liegt => falscher Tag
                    return false;
                if (_TriggerSettings.Daily.Interval == 0) // 0: Trigger ist nicht aktiv
                    return false;
                DateTime RunTime = _StartDate.Date;
                while (RunTime.Date < date)
                    RunTime = RunTime.AddDays(_TriggerSettings.Daily.Interval);
                return (RunTime == date);
            }

            /// <summary>
            /// Trigger-Prüfung für wöchentliche Ausführung
            /// </summary>
            /// <returns></returns>
            private bool TriggerWeekly(DateTime date)
            {
                if ((date < _StartDate.Date) || (date > _EndDate.Date)) // Wenn das Relevante Datum ausserhalb des gültigen Bereichs liegt => falscher Tag
                    return false;
                return (_TriggerSettings.Weekly.DaysOfWeek[(int)date.DayOfWeek]);
            }

            /// <summary>
            /// Trigger-Prüfung für monatliche Ausführung
            /// </summary>
            /// <returns></returns>
            private bool TriggerMonthly(DateTime date)
            {
                if ((date < _StartDate.Date) || (date > _EndDate.Date)) // Wenn das Relevante Datum ausserhalb des gültigen Bereichs liegt => falscher Tag
                    return false;

                bool result = false;
                if (_TriggerSettings.Monthly.Month[date.Month - 1]) // In diesem Monat ausführen?
                {
                    if (_TriggerSettings.Monthly.DaysOfMonth[LastDayOfMonthID]) // Am letzten Tag im Monat ausführen?
                        result = (result || (date == LastDayOfMonth(date))); // ist es der letzte Tag im Monat?

                    result = (result || (_TriggerSettings.Monthly.DaysOfMonth[date.Day - 1])); // Tag ist aktiviert?

                    if (_TriggerSettings.Monthly.WeekDay.DayOfWeek[(int)date.DayOfWeek]) // Tag aktiviert?
                    {
                        if (_TriggerSettings.Monthly.WeekDay.WeekNumber[(int)DayOccurrence.Last]) // Letzes Vorkommen des Tages im Monat prüfen?
                            result = (result || (IsLastWeekDayInMonth(date)));

                        result = (result || _TriggerSettings.Monthly.WeekDay.WeekNumber[WeekDayOccurInMonth(date)]); // n'te Auftreten aktiviert?
                    }
                }
                return result;
            }

            /// <summary>
            /// Prüft ob an einem bestimmten Datum der Trigger ausgelöst würde
            /// </summary>
            /// <returns></returns>
            public bool CheckDate(DateTime date)
            {
                return (TriggerOneTimeOnly(date) || TriggerDaily(date) || TriggerWeekly(date) || TriggerMonthly(date));
            }

            /// <summary>
            /// Führt einen Triggerchek an einen bestimmten Zeitpunkt durch
            /// </summary>
            /// <param name="dateTime"></param>
            /// <returns></returns>
            public bool RunCheck(DateTime dateTimeToCheck)
            {
                if (dateTimeToCheck == DateTime.MaxValue)
                    return false; 

                if (_Enabled) // Trigger aktiv?
                {
                    DateTime triggerDateTime = GetNextTriggerDateTime();
                    if ((dateTimeToCheck >= triggerDateTime) && (dateTimeToCheck <= triggerDateTime.AddTicks(_HitTimeSpan.Ticks))) // Trigger-Zeit überschritten? => Trigger auslösen
                    {
                        OnTriggerEventArgs eventArgs = new OnTriggerEventArgs(this, triggerDateTime);
                        _NextTriggerDate = FindNextTriggerDate(_NextTriggerDate.AddDays(1)); // Einen Tag später fortfahren
                        if (OnTrigger != null) 
                            OnTrigger(this, eventArgs);
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Sucht den Zeitpunkt der nächsten Ausführung
            /// </summary>
            private DateTime FindNextTriggerDate(DateTime searchStartDateTime)
            {
                DateTime date = searchStartDateTime.Date;

                // Wenn die aktuelle Uhrzeit die TriggerTime überschritten hat die Suche am nächsten Tag fortsetzen
                if (searchStartDateTime.TimeOfDay > _TriggerTime.TimeOfDay)
                    date = date.AddDays(1);

                while (date <= _EndDate)
                {
                    if (CheckDate(date))
                        return date;
                    date = date.AddDays(1);
                }
                return DateTime.MaxValue;
            }

            /// <summary>
            /// Ermittelt das Datum der nächsten Ausführung unabhänging der Trigger-Zeit
            /// </summary>
            /// <returns></returns>
            public DateTime GetNextTriggerDateTime()
            {
                if ((!_Enabled) || (_NextTriggerDate==DateTime.MaxValue))
                    return DateTime.MaxValue;
                return new DateTime(_NextTriggerDate.Year, _NextTriggerDate.Month, _NextTriggerDate.Day, _TriggerTime.Hour, _TriggerTime.Minute, _TriggerTime.Second);
            }
        }

        /// <summary>
        /// Stellt eine Collection von TriggerItems dar
        /// </summary>
        [XmlRoot(ElementName = "TriggerItemCollection")]
        public class TriggerItemCollection : CollectionBase
        {
            public TriggerItem this[int index]
            {
                get
                {
                    return ((TriggerItem)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }

            public int Add(TriggerItem value)
            {
                return (List.Add(value));
            }

            public void AddRange(TriggerItemCollection items, TriggerItem.OnTriggerEventHandler handler)
            {
                foreach (TriggerItem item in items)
                {
                    item.OnTrigger += handler;
                    Add(item);
                }
            }

            public int IndexOf(TriggerItem value)
            {
                return (List.IndexOf(value));
            }

            public void Insert(int index, TriggerItem value)
            {
                List.Insert(index, value);
            }

            public void Remove(TriggerItem value)
            {
                List.Remove(value);
            }

            public bool Contains(TriggerItem value)
            {
                return (List.Contains(value));
            }

            protected override void OnInsert(int index, Object value)
            {
            }

            protected override void OnRemove(int index, Object value)
            {
            }

            protected override void OnSet(int index, Object oldValue, Object newValue)
            {
            }

            protected override void OnValidate(Object value)
            {
                if (value.GetType() != typeof(TaskScheduler.TriggerItem))
                    throw new ArgumentException("Das angegebene Argument ist kein TaskScheduler-Element", "value");
            }

            /// <summary>
            /// Serialisiert die gesamte Collection in einen XML-String
            /// </summary>
            /// <returns></returns>
            public String ToXML() // Konfiguration im XML-Format als String ausgeben
            {
                XmlSerializer ser = new XmlSerializer(typeof(TriggerItemCollection));
                TextWriter writer = new StringWriter();
                ser.Serialize(writer, this);
                writer.Close();
                return writer.ToString();
            }

            /// <summary>
            /// Erzeugt eine TriggerItemCollection aus einem XML-String
            /// </summary>
            /// <param name="Configuration"></param>
            /// <returns></returns>
            public static TriggerItemCollection FromXML(String Configuration)
            {
                XmlSerializer ser = new XmlSerializer(typeof(TriggerItemCollection));
                TextReader reader = new StringReader(Configuration);
                TriggerItemCollection result = (TriggerItemCollection)ser.Deserialize(reader);
                reader.Close();
                return result;
            }
        }

        /// <summary>
        /// Collection von TriggerItems
        /// </summary>
        private TriggerItemCollection _triggerItems;

        /// <summary>
        /// Pause zwischen den einzelnen Trigger-Checks in Millisekunden
        /// </summary>
        private int _Interval = 500; // Standard ist jede Halbe Sekunde einen TriggerCheck ausführen

        /// <summary>
        /// Scheduler aktiv?
        /// </summary>
        private bool _Enabled = false;

        /// <summary>
        /// Check-Timer für den Trigger
        /// </summary>
        private Timer _triggerTimer;

        /// <summary>
        /// Klassen-Konstruktor...
        /// </summary>
        public TaskScheduler()
        {
            _triggerItems = new TriggerItemCollection();
            _triggerTimer = new Timer();
            _triggerTimer.Elapsed += new ElapsedEventHandler(_triggerTimer_Tick);
        }

        /// <summary>
        /// Ermittelt den Trigger-Prüfinterval oder legt diesen fest
        /// </summary>
        public int Interval
        {
            get
            {
                return _Interval;
            }
            set
            {
                _Interval = value;
                _triggerTimer.Stop();
                _triggerTimer.Interval = _Interval;
                _triggerTimer.Start();
            }
        }

        /// <summary>
        /// Scheduler aktivieren/deaktivieren
        /// </summary>
        public bool Enabled
        {
            get
            {
                return _Enabled;
            }
            set
            {
                _Enabled = value;
                if (_Enabled) Start();
                else
                    Stop();
            }
        }

        /// <summary>
        /// Ruft das Objekt ab, das zum Marshallen von Ereignishandleraufrufen verwendet
        /// wird, die an OnTrigger gesendet werden, oder legt dieses fest.
        /// </summary>
        public System.ComponentModel.ISynchronizeInvoke SynchronizingObject
        {
            get
            {
                return _triggerTimer.SynchronizingObject;
            }
            set
            {
                _triggerTimer.SynchronizingObject = value;
            }
        }

        /// <summary>
        /// Fügt ein neues Trigger-Item hinzu
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public TriggerItem AddTrigger(TriggerItem item)
        {
            return _triggerItems[_triggerItems.Add(item)];
        }

        /// <summary>
        /// Aktiviert den Scheduler
        /// </summary>
        private void Start()
        {
            if (_triggerTimer.Enabled)
                _triggerTimer.Stop();
            _triggerTimer.Interval = _Interval;
            _triggerTimer.Start();
        }

        /// <summary>
        /// Stoppt den Scheduler
        /// </summary>
        private void Stop()
        {
            _triggerTimer.Stop();
        }

        /// <summary>
        /// Stellt eine Liste mit TriggerItems dar
        /// </summary>
        public TriggerItemCollection TriggerItems
        {
            get
            {
                return _triggerItems;
            }
        }

        /// <summary>
        /// Ereignisbehandlung für den Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _triggerTimer_Tick(object source, ElapsedEventArgs e)
        {
            _triggerTimer.Stop();
            foreach (TriggerItem item in TriggerItems)
                item.RunCheck(DateTime.Now);
            _triggerTimer.Start();
        }
    }
}
