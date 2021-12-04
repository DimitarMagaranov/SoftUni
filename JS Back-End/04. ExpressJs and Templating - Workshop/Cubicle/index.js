const express = require('express');

const config = require('./config/config');
const routes = require('./routes');
const app = express();

// const expressConfig = require('./config/express');
// expressConfig(app);
// OR on a single line code:
require('./config/express')(app);

app.use(routes);

app.listen(config.PORT, () => console.log(`Server is running on port ${config.PORT}...`));