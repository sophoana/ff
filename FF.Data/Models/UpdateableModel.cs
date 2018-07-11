using FF.Contracts.Service;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Models
{
    public class UpdateableModel : ModelBase
    {
        private IDateTimeService _dateTimeService;

        public UpdateableModel()
        {
            _dateTimeService = new DateTimeService();
            InitializeDateTimeService();
        }

        private void InitializeDateTimeService()
        {
            var now = _dateTimeService.UtcNow();
            AddedWhen = now;
            UpdatedWhen = now;
        }

        /// <summary>
        /// Use this for testing purposes. It resets the 
        /// AddedWhen and UpdatedWhen values
        /// </summary>
        public IDateTimeService DateTimeService
        {
            get { return _dateTimeService; }
            set
            {
                _dateTimeService = value;
                InitializeDateTimeService();
            }
        }

        [Required]
        public int AddedBy { get; set; }

        [Required]
        public DateTime AddedWhen { get; set; }

        [Required]
        public int UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedWhen { get; set; }

        public bool IsApproved { get; set; }


        [NotMapped]
        public int CurrentUser { get; set; }

        public void Modified()
        {
            ErrorOnNoCurrentUser();
            if (CurrentUser == 0)
            {
                throw new ArgumentException("Current user must be specified before entity modification");
            }

            if (AddedBy == 0)
            {
                AddedBy = CurrentUser;
            }

            UpdatedBy = CurrentUser;
            UpdatedWhen = _dateTimeService.UtcNow();
        }

        private void ErrorOnNoCurrentUser()
        {
            if (CurrentUser == 0)
            {
                throw new ArgumentException("Current user must be specified before entity modification");
            }
        }

    }
}
