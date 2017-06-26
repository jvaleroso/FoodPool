import { Injectable } from '@angular/core';
import { Stall } from '../../models/stall';
import { Headers, Http } from '@angular/http';

import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class StallService
{
    private stallUrl = 'api/stall';
    private headers = new Headers({'Content-Type': 'application/json'});

    constructor(private http: Http) { }

    getStalls(): Observable<Stall[]>{

        return this.http.get(this.stallUrl)
				        .map(this.extractData)
				        .catch(this.handleError);
    }

     getStall(id: string): Promise<Stall>{

        const url = `${this.stallUrl}/${id}`;

        return this.http.get(url).toPromise()
                        .then(response=>response.json() as Stall)
                        .catch(this.handleError);
    }

    search(term: string): Observable<Stall[]>
    {
        const url = `${this.stallUrl}/?name=${term}`;
        return this.http.get(url).map(response => response.json() as Stall[]);
    }

    delete(id:string): Promise<void>
    {
        const url = `${this.stallUrl}/${id}`;
        return this.http.delete(url, { headers: this.headers })
                        .toPromise()
                        .then(() => null)
                        .catch(this.handleError);
    }

    create(stall: Stall): Observable<Stall> {
        return this.http.post(this.stallUrl, JSON.stringify(stall),{ headers: this.headers})
                   // .toPromise()
                  //  .then(res=> res.json() as Stall)
                    .map(this.extractData)
                    .catch(this.handleError);
    }

    update(stall: Stall): Promise<Stall>
    {
        const url = `${this.stallUrl}/${stall.id}`;

        return this.http.put(url, JSON.stringify(stall), {headers: this.headers})
				        .toPromise().then(()=>stall)
				        .catch(this.handleError);
    }

    private handleError(error: any)
    {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }

    private extractData(data)
    {
        let jsonData = data.json();
        return jsonData;
    }
}