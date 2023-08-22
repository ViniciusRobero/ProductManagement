import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';

//var apiUrl = "https://localhost:44370/";

var apiUrl = "https://localhost:44308";

var httpLink = {
  products: apiUrl + "/api/products"
}

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {

  constructor(private webApiService: WebApiService) { }

  public getAllProducts(): Observable<any> {
    return this.webApiService.get(httpLink.products);
  }

  public deleteProductById(id: any): Observable<any> {
    return this.webApiService.delete(httpLink.products + '/' + id);
  }

  public getProductDetailById(id: any): Observable<any> {
    return this.webApiService.get(httpLink.products + '/' + id);
  }

  public saveProduct(model: any): Observable<any> {
    return this.webApiService.post(httpLink.products, model);
  }
}
