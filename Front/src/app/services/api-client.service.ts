import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) { }

  backend = "http://localhost:5264/"

  get(url: string) {
    return this.http
      .get(this.backend + url)
  }

  post(url: string, obj: any)
  {
    return this.http.post(this.backend + url, obj)
  }
}
