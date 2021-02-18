function solve(obj) {
    const validValues = {
        validValuesForMethod: ["GET", "POST", "DELETE", "CONNECT"],
        validVersions: ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"],
    };

    if(! (obj.method && validValues.validValuesForMethod.includes(obj.method))){
        throw new Error("Invalid request header: Invalid Method");
    }

    let uriRegex = /^[\w.]+$/;

    if(! (obj.uri && ( uriRegex.test(obj.uri) || obj.uri == "*"))){
        throw new Error("Invalid request header: Invalid URI");
    }

    if(! (obj.version && validValues.validVersions.includes(obj.version))){
        throw new Error("Invalid request header: Invalid Version");
    }

    let messageRegex = /^[^<>\\&'"]*$/;

    if(! ( obj.hasOwnProperty("message") && (messageRegex.test(obj.message) || obj.message == ""))) {
        throw new Error("Invalid request header: Invalid Message");
    }

    return obj;
}

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));

console.log(solve({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
  }));

  console.log(solve({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
  }));