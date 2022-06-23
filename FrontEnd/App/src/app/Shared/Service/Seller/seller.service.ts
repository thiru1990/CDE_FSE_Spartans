import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders,HttpParams} from '@angular/common/http';
import { Observable,pipe,throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ProductRequest } from 'src/app/Model/ProductRequest';
import { Products } from 'src/app/Model/Products';
import { map } from 'rxjs/operators'


@Injectable({
  providedIn: 'root'
})
export class SellerService {

  constructor( private readonly _httpClient:HttpClient  ) { }

  addProduct(productdetails:any,token:any){
    console.log("Addprofuctinput",productdetails);       
    const httpOptions = {
      headers: new HttpHeaders().set("Authorization","Bearer "+token)}
      //headers: new HttpHeaders().set("Authorization",token)      
    return this._httpClient.post<any>(environment.apiSellerUrl+'/add-product',productdetails,httpOptions).pipe(catchError(this.handleError))
  }
  deleteProductId(productid:string,token:any){
    console.log("deleteproductid",productid);
    let options = {
      headers: new HttpHeaders({ 'Authorization':'Bearer '+token,'Content-Type': 'application/json' } ),
      params:new HttpParams().set('productId', productid)
     };   
      console.log("options",options);
    return this._httpClient.delete<any>(environment.apiSellerUrl+'/delete',options).pipe(catchError(this.handleError))
  }
  GetProductss(token:any){
    let options = {
      headers: new HttpHeaders({ 'Authorization':'Bearer '+token,'Content-Type': 'application/json' } ),      
     };   
    return this._httpClient.get<Products[]>(environment.apiSellerUrl+'/GetProductDetails').pipe(catchError(this.handleError))
    }

    GetProducts(token:any): Observable<Products[]> {  
      let options = {
        headers: new HttpHeaders({ 'Authorization':'Bearer '+token,'Content-Type': 'application/json' } ),      
       };
      return this._httpClient.get<Products[]>(environment.apiSellerUrl+'/GetProductDetails',options).pipe(catchError(this.handleError))
  }   

  GetBidDetails(productId:string,token:any){
        let options = {
         headers: new HttpHeaders({ 'Authorization':'Bearer '+token,'Content-Type': 'application/json' } ),
          params:new HttpParams().set('productId', productId)
         };   
          console.log("options",options);
        return this._httpClient.get<any>(environment.apiSellerUrl+'/show-bids',options).pipe(catchError(this.handleError))
  } 
  private handleError(err:HttpErrorResponse){
    console.log('Error message', err.message);
    return throwError(()=>err.message);
  }
}
