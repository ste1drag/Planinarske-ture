// filepath: /c:/Users/steva/OneDrive/Desktop/rs2/Planinarske-ture/frontend/postcss.config.js
module.exports = {
  plugins: [
    require("postcss-preset-env")({
      stage: 1,
      features: {
        "nesting-rules": true,
      },
    }),
    require("@csstools/postcss-progressive-custom-properties"),
  ],
};
