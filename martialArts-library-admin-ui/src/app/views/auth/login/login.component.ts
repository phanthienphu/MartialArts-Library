import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule  } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminApiAuthApiClient, AuthenticatedResult, LoginRequest } from 'src/app/api/admin-api.service.generated';
import { AlertService } from 'src/app/shared/services/alert.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm:FormGroup;
  constructor(private fb:FormBuilder,
    private authApiClient:AdminApiAuthApiClient,
    private alertService:AlertService,
   private router : Router) { 
    this.loginForm=this.fb.group({
      userName: new FormControl('',Validators.required),
      passWord: new FormControl('',Validators.required)
    });
  }
  login(){
    var request: LoginRequest = new LoginRequest({
      userName:this.loginForm.controls['userName'].value,
      password:this.loginForm.controls['passWord'].value
    });

    this.authApiClient.login(request).subscribe({
      next:(res:AuthenticatedResult) =>{
        //save token and refresh token to localstorege
        
        //Redirec doashboard
        this.router.navigate(['/dashboard']);
      },
      error:(error:any)=>{
        console.log(error);
        this.alertService.showError('Login invalid')
      }
    });
  }
}
