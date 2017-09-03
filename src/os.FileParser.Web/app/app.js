'use strict';

var app = angular
    .module('app', [
    // Angular modules
    'ui.router',
    'LocalStorageModule',
    'ngMessages',
    'angularMoment',
    'ngFileSaver',
    'chart.js'
    // Custom modules 
    
    // 3rd Party Modules

    ]);

app.constant('apiBaseUri', 'http://localhost:65286');

app.constant('angularMomentConfig', {
    preprocess: 'utc',
    timezone: 'Africa/Johannesburg'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

//app.run(['securityFactory', function (authService) {
//    authService.fillAuthData();
//}]);