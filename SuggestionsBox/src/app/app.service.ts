import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/retry';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/of';
import { Http, Response, RequestOptions, Headers } from '@angular/http';

@Injectable()
export class AppService {

    baseUrl = './../api/suggestionsbox/';

  constructor(private http: Http) { }

      // GET
      public getData(path: string) {
        const results = this.http.get(this.baseUrl + path)
        .map(res => res.json())
            .catch(this.handleError).delay(2000).retry(1);
        return results;
    }

    // POST
    public postData(path: string, data: any, options?: any) {
        return  this.http.post(this.baseUrl + path, data).map((res: Response) => res.json())
            .catch(this.handleError);
    }

    // PUT
    public putData(path: string, data: any, options?: any) {
        return  this.http.put(this.baseUrl + path, data).map((res: Response) => res.json())
            .catch(this.handleError);
    }


    private handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            try {
                const body = error.json()|| '';
                const errMessage = body.message || JSON.stringify(body);
                errMsg = `${error.status} - ${error.statusText || ''} ${errMessage}`;
            } catch (e) {
                errMsg = error.statusText || '';
            }
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        return Observable.throw(errMsg);
    }
}
