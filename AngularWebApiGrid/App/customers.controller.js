(function () {
    'use strict';

    angular
        .module('app')
        .controller('CustomersController', CustomersController);

    CustomersController.$inject = ['Restangular', 'ngTableParams'];

    function CustomersController(Restangular, ngTableParams) {
        /* jshint validthis:true */
        var vm = this;

        vm.tableParams = new ngTableParams({
            page: 1,
            count: 10
        },
        {
            getData: function ($defer, params) {
                // Load the data from the API
                Restangular.all('customers').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (customers) {
                    // Tell ngTable how many records we have (so it can set up paging)
                    params.total(customers.paging.totalRecordCount);

                    // Return the customers to ngTable
                    $defer.resolve(customers);
                }, function (response) {
                    // Notify of error
                });
            }
        });

        activate();

        function activate() {
        }
    }
})();