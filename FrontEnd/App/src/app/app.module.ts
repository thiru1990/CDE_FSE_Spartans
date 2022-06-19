import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { NoopAnimationsModule,BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuctionNavbarComponent } from './NavBar/auction-navbar/auction-navbar.component';
import { AuctionFooterComponent } from './footer/auction-footer/auction-footer.component';
import { BuyerComponent } from './buyer/buyer.component';
import { SellerComponent } from './seller/seller.component';
import { BidDetailsComponent } from './bid-details/bid-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {DialogModule} from 'primeng/dialog';
import { LoginComponent } from './login/login.component';
  

@NgModule({
  declarations: [
    AppComponent,
    AuctionNavbarComponent,
    AuctionFooterComponent,
    BuyerComponent,
    SellerComponent,
    BidDetailsComponent,
    LoginComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    DialogModule,
    NoopAnimationsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
