using Microsoft.Extensions.Configuration;
using RPM_Programming_Excercise.Common;
using RPM_Programming_Excercise.Models;
using RPM_Programming_Excercise.Repositories.PetroleumPriceRepository;
using System;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Managers.PetroleumManager
{
    public class PetroleumPriceManager : IPetroleumPriceManager
    {
        private readonly IConfiguration _configuration;
        private readonly IPetroleumPriceRepository _petroleumPriceRepository;

        public PetroleumPriceManager(IPetroleumPriceRepository petroleumPriceRepository, IConfiguration configuration)
        {
            _petroleumPriceRepository = petroleumPriceRepository;
            _configuration = configuration;
        }

        public async Task InsertIfNotExistsAsync(PetroleumModel model)
        {
            int daysCount = _configuration.GetValue<int>(Constants.CustomValuesConfiguration.ValueKeys.DaysCountKey);
            var minimumDateTime = DateTime.UtcNow.AddDays(-daysCount);

            if (model.Period >= minimumDateTime)
            {
                await _petroleumPriceRepository.InsertIfNotExistsAsync(model);
            }
        }
    }
}
