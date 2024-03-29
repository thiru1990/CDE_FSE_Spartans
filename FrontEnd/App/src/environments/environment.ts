// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
 // apiUrl:'http://localhost:2503/api/1/buyer',
 // apiSellerUrl:'http://localhost:32915/e-auction/api/1/seller'
 apiUrl:'https://eauction.azure-api.net/api/1/buyer',
 apiSellerUrl:'https://eauction.azure-api.net/Seller/e-auction/api/1/seller'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
