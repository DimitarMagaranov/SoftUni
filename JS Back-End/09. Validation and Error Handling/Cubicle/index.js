const express = require('express');
const errorHandler = require('./middlewares/errorHandler');


const config = require('./config');
const routes = require('./routes');
const app = express();

// const expressConfig = require('./config/express');
// expressConfig(app);
// OR on a single line code:
require('./config/express')(app);
require('./config/mongoose')(app);

app.use(routes);
app.use(errorHandler);

app.listen(config.PORT, () => console.log(`Server is running on port ${config.PORT}...`));