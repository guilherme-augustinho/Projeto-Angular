import { Injectable } from '@angular/core';
import { ClientData } from '../DTO/client-data';
import { ApiClientService } from './api-client.service';


@Injectable({
  providedIn: 'root'
})
export class ClientServiceService {
  constructor(private http: ApiClientService) { }

  register(data: ClientData)
  {
    this.http.post("user", data)
      .subscribe(r => console.log(r))
  }
}
