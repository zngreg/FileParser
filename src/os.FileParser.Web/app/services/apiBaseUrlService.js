'use strict';

app.service('apiBaseUrlService', ['$http', 'apiBaseUri', function ($http, apiBaseUri) {

    var _serviceBase = apiBaseUri;

    var apiBaseUrlServiceFactory = {};

    apiBaseUrlServiceFactory.getserviceBaseUrl = _serviceBase;

    return apiBaseUrlServiceFactory;
}]);