import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse} from '@angular/common/http';
import { Observable,pipe,throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { BidRequest } from 'src/app/Model/Buyer-Placebid';
import { UpdatBid } from 'src/app/Model/updateBid';


@Injectable({
  providedIn: 'root'
})
export class BuyerService {

  constructor(  private readonly _httpClient:HttpClient ) { }
  placeBidDetails(bidDetails:any){
    console.log('serviceinput',bidDetails);
    return this._httpClient.post<any>(environment.apiUrl+'/place-bid',bidDetails).pipe(catchError(this.handleError))

  }
  UpdateBidDetails(UpdatebidDetails:UpdatBid){
    console.log('serviceinput',UpdatebidDetails);
   return this._httpClient.post<any>(environment.apiUrl+'/update-bid',UpdatebidDetails).pipe(catchError(this.handleError))
  }
   
  private handleError(err:HttpErrorResponse){
    return throwError(()=>err.message);
  }
}
