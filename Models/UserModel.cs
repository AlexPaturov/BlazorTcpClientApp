// Models/UserModel.cs
using System.ComponentModel.DataAnnotations;

namespace BlazorTcpClientApp.Models
{
    public class UserModel
    {
        /// <summary>
        /// Доменное имя пользователя.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Отображаемое имя пользователя.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Доменное имя ПК пользователя.
        /// </summary>
        public string PCName { get; set; }

        /// <summary>
        /// Табельный номер пользователя.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// true - текущий пользователь - весовщик
        /// </summary>
        public bool IsGdWeighter { get; set; }

        /// <summary>
        /// номер весов
        /// </summary>
        [Required]
        [StringLength(3, MinimumLength = 1)]
        public string Vesy { get; set; }

        /// <summary>
        /// true - текущий ПК принадлежит к общей группе жд весов (1,2,4,7,9,10,13,17,31)
        /// без ограничений.
        /// </summary>
        public bool IsPcGdWeight { get; set; }

        /// <summary>
        /// true - текущий ПК принадлежит к группе взвешиваний чугуна (16,33)
        /// без ограничений.
        /// </summary>
        public bool IsPcChugunWeight { get; set; }

        /// <summary>
        /// true - текущий ПК принадлежит к группе взвешиваний шлака (6)
        /// без ограничений.
        /// </summary>
        public bool IsPcVesySix { get; set; }

        /// <summary>
        /// true - текущий пользователь принадлежит к группе автовесов
        /// </summary>
        public bool IsUserAvtoWeighterGroup { get; set; }

        /// <summary>
        /// true - текущий пользователь принадлежит к группе мастеров смены
        /// </summary>
        public bool IsUserShiftForeman { get; set; }

        /// <summary>
        /// true - текущий пользователь принадлежит к группе пользователей с обычным набором прав
        /// </summary>
        public bool IsUserAVG { get; set; }

        /// <summary>
        /// true - текущий пользователь может смотреть взвешивания по автовесам
        /// </summary>
        public bool IsUserCanSeeAvtoWeighting { get; set; }

        /// <summary>
        /// true - текущий ПК принадлежит к группе автовесов
        /// </summary>
        public bool IsPCAvtoWeighterGroup { get; set; }

        /// <summary>
        /// true - флаг первого заполнения объекта или проверка прав.
        /// При заполнении объекта данными ставим флаг в false и больше не делаем проверок и вычитки данных их LDAP и проверку набора
        /// прав у текущего пользователя.
        /// </summary>
        public bool WasCheckedUserRight { get; set; }

        /// <summary>
        /// true - получили ошибку; false - ошибок не было;
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Пустая строка - сообщений об ошибках не было.
        /// </summary>
        public string ErrorText { get; set; }

        /// ----------------- добавил поле для наладки -----------------------
        /// <summary>
        /// Пустая строка - сообщений об ошибках не было.
        /// </summary>
        public string ReceivedData { get; set; } = string.Empty;


        /// <summary>
        /// true - текущий
        /// </summary>
        // public bool IsActive { get; set; } = false;
    }
}
