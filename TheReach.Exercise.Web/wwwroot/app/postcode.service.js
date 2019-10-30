(function () {

    'use strict';
    angular
        .module('app')
        .service('PostcodeService', PostcodeService);

    PostcodeService.$inject = ['$http'];

    function PostcodeService($http) {
        this.getPostcodeDetails = getPostcodeDetails;
        function getPostcodeDetails() {
            return $http({
                method: 'GET',
                url: '/api/Postcode'
            });
        };
        this.getStateDetails = getStateDetails;
        function getStateDetails(countryCode) {
            return $http({
                method: 'GET',
                url: '/api/Postcode/States/' + countryCode
            });
        };
        this.getLocalityDetails = getLocalityDetails;
        function getLocalityDetails(stateCode) {
            return $http({
                method: 'GET',
                url: '/api/Postcode/Localities/' + stateCode
            });
        }
    }
})()