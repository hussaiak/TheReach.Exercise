(function () {
    'use strict';
    angular
        .module('app')
        .service('CountryService', CountryService);
    CountryService.$inject = ['$http'];

    function CountryService($http) {
        this.getCountryDetails = getCountryDetails;
        function getCountryDetails() {
            return $http({
                method: 'GET',
                url: '/api/country'
            });
        }
    }
})();