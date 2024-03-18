namespace ClientsBaseApplication.Data
{
    /// <summary>
    /// Данные о человеке(персоне).
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Идентификационный номер человека(Первичный ключ для базы данных).
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// Фамилия имя и отчество человека.
        /// </summary>
        public String? FullNamePerson { get; set; }

        /// <summary>
        /// Возраст человека.
        /// </summary>
        public Int32 Age { get; set; }

        /// <summary>
        /// Пол человека.
        /// </summary>
        public String? Gender { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public Int32 Phone { get; set; }

    }
}
