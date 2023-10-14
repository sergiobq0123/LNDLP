import { Inject, Injectable } from '@angular/core';
import { Urls } from '../common/urls';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Filter } from '../components/intranet/general/generic-table/Filter';

@Injectable({
  providedIn: 'root'
})
export class ServiceBaseService {

  protected urlBase = Urls.BASE;
  protected controllerName: string;

  protected get getUrl(){
     return this.urlBase + this.controllerName;
  }

  constructor(private http: HttpClient, @Inject(String) url: string) {
    this.controllerName = url;
  }

  public get(): Observable<any>;

  public get(): Observable<any>;

  public get(id: number): Observable<any>;

  public get(id?: number): Observable<any>{
    if(id) {
      return this.http.get(`${this.getUrl}/${id}`);
    }else{
      return this.http.get(this.getUrl);
    }
  }

  public getWithParams(url: string, params: HttpParams): Observable<any>{
    return this.http.post(url, {params});
  }

  public getCards():Observable<any>{
    return this.http.get(this.getUrl + '/Cards');
  }

  public getToSpecificURL(url?: string):Observable<any>{
    return this.http.get(url);
  }

  public postSpecificUrl(url: string, data :any):Observable<any>{
    return this.http.post(url, data);
  }

  public create(data: any): Observable<any>{
    return this.http.post(this.getUrl, data)
  }
  public update(id: number, data: any): Observable<any>{
    return this.http.put(`${this.getUrl}/${id}`, data)
  }
  public updateAll(data: any): Observable<any>{
    return this.http.put(this.getUrl, data)
  }
  public post(url: string, data: any): Observable<any>{
    return this.http.post(url, data)
  }
  public delete(id: number): Observable<any>{
    return this.http.delete(`${this.getUrl}/${id}`)
  }


  public getFiltered(filters: Filter[]):Observable<any> {
    let params : any [] = filters.map( f => {
      return {
        dataKey: f.dataKey,
        type : f.type,
        condition: f.condition,
        filterInput: f.filterInput,
        startDate : f.startDate,
        endDate: f.endDate
      }
    })
    return this.http.post(this.getUrl + "/filter", params)
  }

  public getIntranet(): Observable<any>{
    return this.getToSpecificURL(this.getUrl + Urls.INTRANET)
  };
  public getKeys(): Observable<any>{
    return this.getToSpecificURL(this.getUrl + Urls.KEYS)
  };

}
