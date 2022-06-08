const { TsConfigPathsPlugin } = require('awesome-typescript-loader');

module.exports = {
    mode: 'development',
    output: {
        filename: '[name].js'
    },
    entry: {
        global: './Cds.TestDashboard.Web/UI/ts/root/global.ts'
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                loader: 'ts-loader',
                exclude: /node_modules/
            },
            {
                test: /\.tsx/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: [ '@babel/preset-env', '@babel/preset-react', '@babel/preset-typescript' ]
                    }
                }
            }
        ]
    },

    resolve: {
        extensions: ['.ts', '.js', '.tsx'],
        plugins: [
            new TsConfigPathsPlugin({
                configFileName: './tsconfig.json'
            })
        ]
    }
}