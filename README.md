The Gene Ric IDP
================

An [IDP](https://en.wikipedia.org/wiki/Identity_provider) distributed as a docker container that will handle all the generic [OpenID Connect](http://openid.net/connect/) stuff, while having extensibility points that allows you to customize the UI etc.


## The idea so far

This is still early days, but this is the current vision.

You start the gene-ric-idp container in your network and tell it which providers it should support (facebook, google, twitter etc). You also tell it where to get the different UIs - i.e. you provide it with a URL that the IDP will make a server-to-server request to in order to obtain the HTML etc. that should be shown to the user.
