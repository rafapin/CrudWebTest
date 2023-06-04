import { Injectable } from '@angular/core';
import { lastValueFrom, tap } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

export interface Options {
	headers?: HttpHeaders;
	params?: HttpParams;
}

@Injectable()
export class HttpService {

  constructor(private readonly http: HttpClient) {}

	public createDefaultOptions(): Options {
		return {
			headers: new HttpHeaders({
				Accept: 'application/json',
				'Content-Type': 'application/json',
			}),
		};
	}

	public optsName(name: string): Options {
		return this.setHeader('xhr-name', name);
	}

	private setHeader(name: string, value: string): Options {
		const newOpts = this.createDefaultOptions();
		newOpts.headers = newOpts.headers?.set(name, value);
		return newOpts;
	}

	private createOptions(opts?: Options): Options {
		const defaultOpts: Options = this.createDefaultOptions();

		if (!!opts) {
			opts = {
				params: opts.params || defaultOpts.params,
				headers: opts.headers || defaultOpts.headers,
			};

			if (!opts.headers?.get('Content-Type')) {
				opts.headers?.set('Content-Type', defaultOpts.headers?.get('Content-Type') || '');
			}
		}

		return opts || defaultOpts;
	}

	public get<T>(serviceUrl: string, opts?: Options): Promise<T> {
		const _opts = this.createOptions(opts);
		const response$ = this.http.get<T>(serviceUrl, _opts).pipe(
			tap({ next: async (x) => this.handlerResponse(x, false) }),
			map((x) => x)
		);
		return lastValueFrom(response$);
	}
	public post<T, R>(serviceUrl: string, body: T, showOk: boolean = true, opts?: Options): Promise<R> {
		const _opts = this.createOptions(opts);
		const response$ = this.http.post<R>(serviceUrl, body, _opts).pipe(
			tap({ next: async (x) => this.handlerResponse(x, showOk) }),
			map((x) => x)
		);
		return lastValueFrom(response$);
	}

  private  handlerResponse<T>(x: T, showOk: boolean) : void {
		
	}
}
