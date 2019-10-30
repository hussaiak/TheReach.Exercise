(function () {
    'use strict';
    angular
        .module('app')
        .service('UserService', UserService);
    UserService.$inject = ['$http'];

    function UserService($http) {
        this.submitUserDetails = submitUserDetails;
        function submitUserDetails(userDetails) {
            return $http({
                method: 'POST',
                url: '/api/user/Submit',
                data: userDetails
            });
        }
    }
})();