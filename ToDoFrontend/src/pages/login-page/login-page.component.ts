import { Component } from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './login-page.component.html',
  styles: ``
})
export class LoginPageComponent {
  protected isRegistering = false;
  protected loginForm: FormGroup;
  protected errorMessage = '';

  constructor(private fb: FormBuilder, public authService: AuthService) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  public toggleRegistering() {
    this.isRegistering = !this.isRegistering;
  }

  public async onSubmit() {
    if (this.loginForm.valid) {
      if (this.isRegistering) {
        await this.register();
      } else {
        await this.logIn();
      }
    } else {
      console.log('Form is invalid');
    }
  }

  private async logIn() {
    const email = this.loginForm.controls['email'].value;
    const password = this.loginForm.controls['password'].value;
    const success = await this.authService.logIn(email, password);

    if (success) {
      // TODO navigate to home
      return;
    }

    this.errorMessage = "Incorrect email or password";
  }

  private async register() {
    const email = this.loginForm.controls['email'].value;
    const password = this.loginForm.controls['password'].value;
    this.authService.register(email, password);
  }
}
