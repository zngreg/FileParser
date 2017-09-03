(function () {
    'use strict';

    app.factory('filesFactory', filesFactory);

    filesFactory.$inject = ['$http', '$q', 'apiBaseUrlService'];

    function filesFactory($http, $q, apiBaseUrlService) {
        var serviceBase = apiBaseUrlService.getserviceBaseUrl;

        var _uploadNamesFile = function (file) {
          return $http.post(serviceBase + '/api/files/names', file).then(function (response) {
                return response;
            });
        };

        var _uploadAddressesFile = function (file) {
          return $http.post(serviceBase + '/api/files/address', file).then(function (response) {
                return response;
            });
        };
      
        return {
          uploadNamesFile: _uploadNamesFile,
          uploadAddressesFile: _uploadAddressesFile
        }
    }
})();