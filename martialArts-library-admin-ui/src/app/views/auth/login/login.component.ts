import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule  } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminApiAuthApiClient, AuthenticatedResult, LoginRequest } from 'src/app/api/admin-api.service.generated';
import { AlertService } from 'src/app/shared/services/alert.service';
import {UrlConstants} from 'src/app/shared/constants/url.constants'
import { TokenStorageService } from 'src/app/shared/services/token-storage.service';
import { Subject, take, takeUntil } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy{
  loginForm:FormGroup;
  private ngUnsubscribe = new Subject<void>();
  loading = false;

  constructor(private fb:FormBuilder,
    private authApiClient:AdminApiAuthApiClient,
    private alertService:AlertService,
   private router : Router,
  private tokenService:TokenStorageService) { 
    this.loginForm=this.fb.group({
      userName: new FormControl('',Validators.required),
      passWord: new FormControl('',Validators.required)
    });
  }
  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }
  login(){
    this.loading=true;
    var request: LoginRequest = new LoginRequest({
      userName:this.loginForm.controls['userName'].value,
      password:this.loginForm.controls['passWord'].value
    });

    this.authApiClient.login(request)
    .pipe(takeUntil(this.ngUnsubscribe))
    .subscribe({
      next:(res:AuthenticatedResult) =>{
        //save token and refresh token to localstorege
        this.tokenService.saveToken(res.token);
        this.tokenService.saveRefreshToken(res.refreshToken);
        this.tokenService.saveUser(res);
        //Redirec doashboard
        this.router.navigate([UrlConstants.HOME]);
      },
      error:(error:any)=>{
        console.log(error);
        this.alertService.showError('Đăng nhập không đúng!');
        this.loading = false;
      }
    });
  }
}
