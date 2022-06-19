import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../Shared/Service/Authenticate/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  /* form: any = {
    username: null,
    password: null
  }; */
  currentUser:any;
  loginForm: FormGroup;
    loading = false;
    submitted = false;
  isLoggedIn = false;
  isLoginFailed = false;
  email:string='';
  errorMessage = '';
  constructor(private authservice:AuthService,private formBuilder: FormBuilder,
    private route: ActivatedRoute,private router: Router) {

     }

  ngOnInit(): void {
   /*  if (this.authservice.getToken()) {
      this.isLoggedIn = true;
      this.router.navigate(['/']);
    } */
    this.loginForm=this.formBuilder.group({
      Email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)})
  }
  get f(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

  submit():void {
      this.submitted = true;
   // this.email= this.loginForm.get('Email')?.value
      // stop here if form is invalid
      if (this.loginForm.invalid) {
          return;
      }
      this.loading = true;
      this.authservice.signIn(
        this.loginForm.get('Email')?.value).subscribe(
        (res:any)=>{
        localStorage.setItem('access_token',res.token);
        this.currentUser=res;
        this.router.navigate(['/Seller']);//check and navigate to seller page
      });
    
  
}
}