import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable, tap} from 'rxjs';

interface AuthResponse {
  userId: string;
  email: string;
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly baseUrl = "http://localhost:5242/auth";

  constructor(private httpClient: HttpClient) {
  }

  public async logIn(username: string, password: string): Promise<boolean> {
    return new Promise((resolve) => {
      this.httpClient.post<AuthResponse>(`${this.baseUrl}/login`, {
        Email: username,
        Password: password,
      }).pipe(
        tap((res: AuthResponse) => {
          localStorage.setItem('token', res.token);
          resolve(true); // Resolve true on success
        })
      ).subscribe({
        error: (err) => {
          resolve(false); // Resolve false on error
        }
      });
    });
  }

  public logOut() {

  }

  public register(username: string, password: string) {

  }
}
