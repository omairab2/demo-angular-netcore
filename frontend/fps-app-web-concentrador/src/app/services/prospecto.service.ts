import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Prospecto } from '../models/prospecto';
import { httpHeaders } from '../utils/constantes';

@Injectable({
  providedIn: 'root'
})
export class ProspectoService {

  endpoint = `${environment.BASE_ENDPOINT}/consulta/prospecto`;
  constructor(protected http: HttpClient) { }


  save(data: any) {
    return this.http.post(this.endpoint, JSON.stringify(data), httpHeaders);
  }


}
