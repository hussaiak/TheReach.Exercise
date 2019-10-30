 
(function () {
    'use strict';
    angular
        .module('app')
        .controller('UserController', UserController);

    UserController.$inject = ['UserService','CountryService', 'PostcodeService'];
    function UserController(UserService,CountryService, PostcodeService) {
        var vm = this;
        vm.title = 'The Reach Exercise Application';
        vm.isSuccess = false;
        vm.isError = false;
        vm.countryModel = {};
        vm.localityModel = {};
        vm.countrydetails = {};
        vm.errorCode = '';
        vm.errorMessage = '';
        vm.getCountryDetails = getCountryDetails; 
        vm.getStateDetails = getStateDetails;
        vm.getLocalityDetails = getLocalityDetails; 
        vm.getPostcode = getPostcode;
        vm.submitUserDetails = submitUserDetails;
        vm.closeSuccessMessage = closeSuccessMessage;
        vm.closeErrorMessage = closeErrorMessage;

        function submitUserDetails() { 
            var userDetails = {
                FullName: vm.userName,
                Country: vm.countryModel.countryName,
                State: vm.stateCode,
                Locality: vm.localityModel.locality,
                Postcode: vm.localityModel.postcode
            }
            var onSuccess = function (response) {
                vm.isError = false;
                vm.isSuccess = true;
                vm.errorCode = '';
                vm.errorMessage = '';  
                vm.successMessage = 'Your application has been successfully submitted.';
            };

            var onError = function (response) {
                vm.isSuccess = false;
                vm.isError = true;
                vm.errorCode = ' HttpStatusCode ' + response.status
                vm.errorMessage = response.data.message;
            }
            UserService.submitUserDetails(userDetails).then(onSuccess, onError);
        };

        function getPostcode() {
            vm.localityModel = JSON.parse(vm.locality);
        };

        function getLocalityDetails() {
            var onSuccess = function (response) {
                vm.isError = false;
                vm.errorCode = '';
                vm.errorMessage = '';
                vm.localitydetails = response.data.length > 0 ? response.data : ''; 
            };

            var onError = function (response) { 
                vm.isError = true;
                vm.errorCode = ' HttpStatusCode ' + response.status
                vm.errorMessage = response.data.message;
            }

            PostcodeService.getLocalityDetails(vm.stateCode).then(onSuccess, onError);
        };

        function getStateDetails() {   
            var onSuccess = function (response) {
                vm.isError = false;
                vm.errorCode = '';
                vm.errorMessage = '';
                vm.statedetails = response.data.length > 0 ? response.data : ''; 
            };

            var onError = function (response) { 
                vm.isError = true;
                vm.errorCode = ' HttpStatusCode ' + response.status
                vm.errorMessage = response.data.message;
            }
            vm.countryModel = JSON.parse(vm.country);
            PostcodeService.getStateDetails(vm.countryModel.countryCode).then(onSuccess, onError);
        }; 

        function getCountryDetails() {
            var onSuccess = function (response) {
                vm.isError = false;
                vm.errorCode = '';
                vm.errorMessage = '';
                vm.countrydetails = response.data; 
            };

            var onError = function (response) { 
                vm.isError = true;
                vm.errorCode = ' HttpStatusCode ' + response.status
                vm.errorMessage = response.data.message;
            }
            CountryService.getCountryDetails().then(onSuccess, onError);
        };

        getCountryDetails();
        function closeSuccessMessage() {
            vm.isSuccess = false;
        } 

        function closeErrorMessage() {
            vm.isError = false;
        } 
    }

})();