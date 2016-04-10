# polymer-rest-aspnetcore

Web application (`single page application`) built wiht ASP.NET Core WebAPI,
static web pages and set of web components from Polymer library. 

## Development

```
cd src/StarterApp
```
- install dependencies
```
dnu restore
```
The `restore` script will also install `NPM` and `Bower` dependencies used in client application.

- to develop C# part:
```
dnx-watch web
```
This will start web api endpoint.

- to develop Polymer client app at the same time:
```
gulp serve
```
This will start Node web server that will host development version of client app

- to create `dist` version of client application you can:
```
dnu build
```
or just:
```
gulp
```


## Author
@peterblazejewicz
