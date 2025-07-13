// filepath: /c:/Users/steva/OneDrive/Desktop/rs2/Planinarske-ture/frontend/webpack.config.js
module.exports = {
  module: {
    rules: [
      {
        test: /\.css$/,
        use: [
          "style-loader",
          "css-loader",
          {
            loader: "postcss-loader",
            options: {
              postcssOptions: {
                plugins: [
                  require("postcss-preset-env")({
                    stage: 1,
                    features: {
                      "nesting-rules": true,
                    },
                  }),
                  require("@csstools/postcss-progressive-custom-properties"),
                ],
              },
            },
          },
          "source-map-loader",
        ],
      },
    ],
  },
};
