using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowershellCommands.Controls;

namespace PowershellCommands.Services
{
    public class TsApiClientController
    {
        private readonly TsApiClientService _service;
        private readonly TsApiClientControl _view;

        public TsApiClientController(TsApiClientService service, TsApiClientControl view)
        {
            _service = service;
            _view = view;
        }

        public async Task DownloadApiDefinitionAsync()
        {
            bool definitionSaved = false;
            bool yarnStarted = false;

            _view.UpdateStepStatus(1, "Pending");
            _view.UpdateStepStatus(2, "Pending");
            _view.UpdateStepStatus(3, "Pending");
            _view.UpdateStepStatus(4, "Pending");

            try
            {
                _view.UpdateStepStatus(1, "In Progress");
                await _service.DownloadEventLogApiDefinitionAsync();
                MessageBox.Show("API definition downloaded successfully! Check console output.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                definitionSaved = true;

                _view.UpdateStepStatus(1, "Completed");
                _view.UpdateStepStatus(2, "Completed");
                _view.UpdateStepStatus(3, "Completed");

                _view.UpdateStepStatus(4, "Pending (running yarn, please wait)");
                yarnStarted = true;
                await _service.GenerateTypeScriptClientAsync();
                _view.UpdateStepStatus(4, "Completed");

                MessageBox.Show("API definition downloaded and TypeScript client generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (!definitionSaved)
                {
                    _view.UpdateStepStatus(1, "Failed");
                    _view.UpdateStepStatus(2, "Failed");
                    _view.UpdateStepStatus(3, "Failed");
                    _view.UpdateStepStatus(4, "Pending");
                }
                else if (yarnStarted)
                {
                    _view.UpdateStepStatus(4, "Failed");
                }

                MessageBox.Show($"Failed to process TS API client steps: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
