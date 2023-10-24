import { Inject, Injectable } from '@angular/core';
import { Urls } from '../common/urls';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Filter } from '../components/intranet/general/generic-filter/filter';

@Injectable({
  providedIn: 'root',
})
export class ServiceBaseService {
  protected urlBase = Urls.BASE;
  protected controllerName: string;

  protected get getUrl() {
    return this.urlBase + this.controllerName;
  }

  constructor(private http: HttpClient, @Inject(String) url: string) {
    this.controllerName = url;
  }

  public getWithParams(url: string, params: HttpParams): Observable<any> {
    return this.http.get(url, { params });
  }

  public getCards(): Observable<any> {
    return this.http.get(this.getUrl + '/Cards');
  }

  public postSpecificUrl(url: string, data: any): Observable<any> {
    return this.http.post(url, data);
  }

  public deleteSpecificUrl(url: string, data: any): Observable<any> {
    return this.http.delete(url, data);
  }

  public create(data: any): Observable<any> {
    return this.http.post(this.getUrl, data);
  }
  public update(id: number, data: any): Observable<any> {
    return this.http.put(`${this.getUrl}/${id}`, data);
  }
  public updateAll(data: any): Observable<any> {
    return this.http.put(this.getUrl, data);
  }
  public post(url: string, data: any): Observable<any> {
    return this.http.post(url, data);
  }
  public delete(id: number): Observable<any> {
    return this.http.delete(`${this.getUrl}/${id}`);
  }

  public getIntranet(): Observable<any> {
    return this.getToSpecificURL(this.getUrl + Urls.INTRANET);
  }
  public getKeys(): Observable<any> {
    return this.getToSpecificURL(this.getUrl + Urls.KEYS);
  }

  public get(
    page?: number,
    size?: number,
    sortBy?: string,
    sortOrder?: string,
    filters?: Filter[]
  ): Observable<any> {
    if (filters && filters.length > 0) {
      return this.getFiltered(filters, page, size, sortBy, sortOrder);
    }
    if ((!page || !size) && (!sortBy || !sortOrder)) {
      return this.http.get(this.getUrl);
    } else if (!page || !size) {
      return this.http.get(this.getUrl, {
        params: { sortBy: sortBy, sortOrder: sortOrder },
      });
    } else if (!sortBy || !sortOrder) {
      return this.http.get(this.getUrl, { params: { page: page, size: size } });
    } else {
      return this.http.get(this.getUrl, {
        params: {
          page: page,
          size: size,
          sortBy: sortBy,
          sortOrder: sortOrder,
        },
      });
    }
  }

  public getToSpecificURL(
    url: string,
    page?: number,
    size?: number,
    sortBy?: string,
    sortOrder?: string,
    filters?: Filter[]
  ): Observable<any> {
    if (filters && filters.length > 0) {
      return this.getFilteredToSpecificURL(
        url,
        filters,
        page,
        size,
        sortBy,
        sortOrder
      );
    }

    if ((!page || !size) && (!sortBy || !sortOrder)) {
      return this.http.get(url);
    } else if (!page || !size) {
      return this.http.get(url, { params: { sortBy, sortOrder } });
    } else if (!sortBy || !sortOrder) {
      return this.http.get(url, { params: { page, size } });
    } else {
      return this.http.get(url, { params: { page, size, sortBy, sortOrder } });
    }
  }

  public getFilterDropdownData(): Observable<any> {
    return this.http.get(this.getUrl + '/filter-dropdown').pipe(
      map((res: any) => {
        return (res.data as string[]).map((d) => {
          return { name: d };
        });
      })
    );
  }

  private getFiltered(
    filters: Filter[],
    page?: number,
    size?: number,
    sortBy?: string,
    sortOrder?: string
  ): Observable<any> {
    let body: any[] = filters.map((f) => {
      return {
        dataKey: f.dataKey,
        type: f.type,
        condition: f.condition,
        filterInput:
          typeof f.filterInput == 'string' ? [f.filterInput] : f.filterInput,
        startDate: f.startDate,
        endDate: f.endDate,
      };
    });
    if ((!page || !size) && (!sortBy || !sortOrder)) {
      return this.http.post(this.getUrl + '/filter', body);
    } else if (!page || !size) {
      return this.http.post(this.getUrl + '/filter', body, {
        params: { sortBy: sortBy, sortOrder: sortOrder },
      });
    } else if (!sortBy || !sortOrder) {
      return this.http.post(this.getUrl + '/filter', body, {
        params: { page: page, size: size },
      });
    } else {
      return this.http.post(this.getUrl + '/filter', body, {
        params: {
          page: page,
          size: size,
          sortBy: sortBy,
          sortOrder: sortOrder,
        },
      });
    }
  }

  public getFilteredToSpecificURL(
    url: string,
    filters: Filter[],
    page?: number,
    size?: number,
    sortBy?: string,
    sortOrder?: string
  ): Observable<any> {
    let body: any[] = filters.map((f) => {
      return {
        dataKey: f.dataKey,
        type: f.type,
        condition: f.condition,
        filterInput:
          typeof f.filterInput == 'string' ? [f.filterInput] : f.filterInput,
        startDate: f.startDate,
        endDate: f.endDate,
      };
    });

    if ((!page || !size) && (!sortBy || !sortOrder)) {
      return this.post(url + '/filter', body);
    } else if (!page || !size) {
      return this.http.post(url + '/filter', body, {
        params: { sortBy, sortOrder },
      });
    } else if (!sortBy || !sortOrder) {
      return this.http.post(url + '/filter', body, { params: { page, size } });
    } else {
      return this.http.post(url + '/filter', body, {
        params: { page, size, sortBy, sortOrder },
      });
    }
  }
}
