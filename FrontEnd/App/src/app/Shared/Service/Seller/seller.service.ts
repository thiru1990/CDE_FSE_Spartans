import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse} from '@angular/common/http';
import { Observable,pipe,throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ProductRequest } from 'src/app/Model/ProductRequest';

@Injectable({
  providedIn: 'root'
})
export class SellerService {

  constructor( private readonly _httpClient:HttpClient  ) { }

  addProduct(productdetails:any){
    console.log("Addprofuctinput",productdetails);
    return this._httpClient.post<any>(environment.apiUrl+'/add-product',productdetails).pipe(catchError(this.handleError))
  }
  deleteProductId(productid:string){
    console.log("deleteproductid",productid);
    return this._httpClient.post<any>(environment.apiUrl+'/delete',productid).pipe(catchError(this.handleError))
  }

  private handleError(err:HttpErrorResponse){
    return throwError(()=>err.message);
  }
}
