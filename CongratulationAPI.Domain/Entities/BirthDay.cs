using CongratulationAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CongratulationAPI.Domain.Entities
{
    /// <summary>
    /// �������� ��� �������� ������������ 
    /// </summary>
    public class BirthDay: EntityBase
    {
        /// <summary>
        /// ���������� ���� ���� ��� ��������
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// ���������� ����� ���� ��� ��������
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// ���� - ������ �� ���� �������� ������ ��� ���
        /// </summary>
        public bool IsPased { get; set; }

        /// <summary>
        /// ������������ �� ���� ���� �������� 
        /// </summary>
        public virtual ICollection<Congratulation> Congratulations { get; set; }

        /// <summary>
        /// ������������ � ������� ���� �������� � ���� ����
        /// </summary>
        public virtual ICollection<User> Users { get; set; }


    }
}
