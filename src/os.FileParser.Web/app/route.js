(function () {
    'use strict';

    app.config(function ($stateProvider, $locationProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/home');

        $stateProvider
            .state('root', {
                abstract: true,
                url: '',
                templateUrl: '/app/views/ui/mainLayout.html'
            })
            .state('root.home', {
                url: '/home',
                templateUrl: '/app/views/home.html',
                controller: 'homeController'
            });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

    });

})();